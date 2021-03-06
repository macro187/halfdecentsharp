# ------------------------------------------------------------------------------
# Copyright (c) 2010, 2011, 2012
# Ron MacNeil <macro@hotmail.com>
#
# Permission to use, copy, modify, and distribute this software for any
# purpose with or without fee is hereby granted, provided that the above
# copyright notice and this permission notice appear in all copies.
#
# THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
# WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
# MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
# ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
# WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
# ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
# OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
# ------------------------------------------------------------------------------


RULE_TARGET := $(TRAITOR_dotfile)
RULE_REQS := $(TRAITOR_srcpreq)
RULE_REQS += $(call PROJ_GetVar,RUNNABLE_dotfile,$(TRAITOR_PROJ))
RULE_OREQ := $(TRAITOR_outdir)


define RULE_COMMANDS
	@echo ""
	@echo "=> Cleaning old output files..."
	rm -rf $$(call SYSTEM_ShellEscape,$$(TRAITOR_outdir))/*
	@echo "=> ...done"
	@echo ""
	@echo "=> Making subdirs..."
	$$(foreach dir,$$(TRAITOR_subdirs),$$(MAKE_CHAR_NEWLINE)	mkdir -p $$(TRAITOR_outdir)/$$(call MAKE_DecodeWord,$$(dir)))
	@echo "=> ...done"
	@echo ""
	@echo "=> Running Traitor..."
	$(call PROJ_GetVar,RUNNABLE_run,$(TRAITOR_PROJ)) $(MAKE_CHAR_BS)
	$(call SYSTEM_ShellEscape,$(call RUNNABLE_ArgPath,$(TRAITOR_srcdir),$(TRAITOR_PROJ))) $(MAKE_CHAR_BS)
	$$(foreach src,$$(TRAITOR_srcs),$$(call PROJ_RuleNewLine,$$(call SYSTEM_ShellEscape,$$(call RUNNABLE_ArgPathFragment,$$(call MAKE_DecodeWord,$$(src)),$$(TRAITOR_PROJ))))) $(MAKE_CHAR_BS)
	$(call SYSTEM_ShellEscape,$(call RUNNABLE_ArgPath,$(TRAITOR_outdir),$(TRAITOR_PROJ)))
	@echo "=> ...done"
	@echo ""
	@echo "=> Updating dotfile..."
	touch $(call SYSTEM_ShellEscape,$(TRAITOR_dotfile))
	@echo "=> ...done"
endef

$(call PROJ_Rule)


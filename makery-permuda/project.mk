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


PROJ_required += $(PERMUDA_PROJ)


PERMUDA_upstream_DESC ?= \
Upstream srcs-preprocess module
$(call PROJ_DeclareVar,PERMUDA_upstream)
PERMUDA_upstream := $(call SRCS_PREPROCESS_GetUpstream)


PERMUDA_srcdir_DESC ?= \
Input source code files root directory (read-only)
$(call PROJ_DeclareVar,PERMUDA_srcdir)
PERMUDA_srcdir = $(call SRCS_PREPROCESS_GetDir,$(PERMUDA_upstream))


PERMUDA_srcs_DESC ?= \
Input source code files relative to PERMUDA_srcdir (read-only)
$(call PROJ_DeclareTargetVar,PERMUDA_srcs)
PERMUDA_srcs = $(call SRCS_PREPROCESS_GetFiles,$(PERMUDA_upstream))


PERMUDA_srcpreq_DESC ?= \
Source code files prerequisite files (read-only)
$(call PROJ_DeclareVar,PERMUDA_srcpreq)
PERMUDA_srcpreq = $(call SRCS_PREPROCESS_GetPreqs,$(PERMUDA_upstream))


$(call PROJ_DeclareTargetVar,PERMUDA_subdirs)
PERMUDA_subdirs = $(filter-out ./,$(dir $(PERMUDA_srcs)))


#
# Hook up to srcs-preprocess pipeline
#
SRCS_PREPROCESS_pipeline += permuda

